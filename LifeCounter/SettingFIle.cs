using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace LifeCounter
{
    // 設定構造体
    public struct SettingFileData
    {
        public  string strWallPaper;
        public  int nPlayerNum;
        public  bool bSubCounterON;
        public  bool bSoundON;
        public  int nLifeInitValue;
        public byte R;
        public byte G;
        public byte B;
    }
    class SettingFIle
    {
        public void LoadFile(ref SettingFileData settingfiledata)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingFileData));
            FileStream fs;
            try
            {
                fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + "settings.xml", FileMode.Open);
            }
            catch (System.IO.FileNotFoundException)
            {
                // 設定ファイル保存
                settingfiledata.nLifeInitValue = 20;
                settingfiledata.nPlayerNum = 2;
                settingfiledata.bSoundON = true;
                settingfiledata.bSoundON = true;
                settingfiledata.strWallPaper = ("back.png");
                settingfiledata.R = 0;
                settingfiledata.G = 0;
                settingfiledata.B = 0;
                this.SaveFile(settingfiledata);
                return;
            }
            // XMLファイルを読み込み、逆シリアル化（復元）する
            settingfiledata = (SettingFileData)serializer.Deserialize(fs);
            fs.Close();

        }
        public void SaveFile(SettingFileData settingfiledata)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingFileData));


            // カレントディレクトリに"settings.xml"というファイルで書き出す
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + "settings.xml", FileMode.Create);

            // オブジェクトをシリアル化してXMLファイルに書き込む
            serializer.Serialize(fs, settingfiledata);
            fs.Close();
        }
    }
}
