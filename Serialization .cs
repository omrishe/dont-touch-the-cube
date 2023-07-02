using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjectV2
{
    [Serializable]
    class Serialization 
    {
        public int health=0;
        public int coins=0;
        public int BoxTop;
        public int BoxLeft;
        
        public void SerializePlayer(Player data,string path)
        {
            FileStream fileStream;
            BinaryFormatter binaryF = new BinaryFormatter();
            fileStream=File.Create(path);
            this.BoxTop = data.Box.Top;
            this.BoxLeft = data.Box.Left;
            this.coins = data.coins;
            this.health = data.health;
            binaryF.Serialize(fileStream, this);//serialzeable data
            fileStream.Close();
        }
        public void SerializeGuard(Guard data, string path)
        {
            FileStream fileStream;
            BinaryFormatter binaryF = new BinaryFormatter();
            if (!File.Exists(path))
                fileStream=File.Create(path);
            fileStream = File.Open(path, FileMode.Append);
            this.BoxTop = data.Box.Top;
            this.BoxLeft = data.Box.Left;
            this.coins = 0;
            this.health = 0;
            binaryF.Serialize(fileStream, this);//serialzeable data
            fileStream.Close();
        }


        public Serialization DeSerialize(string path)
        {
            Serialization sData = null;
            FileStream fs;
            BinaryFormatter binaryF = new BinaryFormatter();
            if(File.Exists(path))
            {
                fs = File.OpenRead(path);
                sData = (Serialization)binaryF.Deserialize(fs);
                fs.Close();
            }
            return sData;
        }
    }

}
