using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Color_yr.Countdown
{
    class XML
    {
        public static string applocal = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public static string config = "config.xml";
        /// <summary>
        /// 使用linq 建立xml
        /// </summary>
        /// <param name="fine">文件</param>
        /// <param name="mode">模式</param>>
        public void CreateFile(string fine, int mode)
        {
            FileInfo file = new FileInfo(applocal + fine);
            if (file.Exists && mode == 1) //文件存在就删除
            {
                file.Delete();
                XElement contacts = new XElement("config");
                contacts.Save(applocal + fine);
            }
            else
            {
                XElement contacts = new XElement("config");
                contacts.Save(applocal + fine);
            }
        }
        /// <summary>
        /// //修改XML文件中的元素
        /// </summary>
        /// <param name="fine">文件名</param>
        /// <param name="type">类型名</param>
        /// <param name="attribute">属性名</param>
        /// <param name="data">数据</param>
        public void setXml(string fine, string type, string attribute, string data)
        {
            if (File.Exists(applocal + fine) == false)
            {
                CreateFile(fine, 0);//创建该文件，如果路径文件夹不存在，则报错。
            }
            ///导入XML文件
            XElement xe = XElement.Load(applocal + fine);
            ///查找被替换的元素
            IEnumerable<XElement> element = from e in xe.Elements("config")
                                            where e.Attribute(type).Value == attribute
                                            select e;
            ///替换为新元素，并保存
            if (element.Count() > 0)
            {
                XElement first = element.First();
                ///替换新的节点
                first.ReplaceNodes(
                new XElement(attribute, data)              ///添加元素Name
                 );
            }
            xe.Save(applocal + fine);
        }
        /// <summary>
        /// //增加元素到XML文件
        /// </summary>
        /// <param name="fine">文件名</param>
        /// <param name="type">类型名</param>
        /// <param name="attribute">属性名</param>
        /// <param name="data">数据</param>
        public void write(string fine, string type, string attribute, string data)
        {
            if (File.Exists(applocal + fine) == false)
            {
                CreateFile(fine, 0);//创建该文件，如果路径文件夹不存在，则报错。
            }
            try
            {
                string a = read(fine, type, attribute);
                if (a != null)
                {
                    setXml(fine, type, attribute, data);
                }
                else
                {
                    ///导入XML文件
                    XElement xe = XElement.Load(applocal + fine);
                    ///创建一个新的节点
                    XElement student = new XElement("config",
                     new XAttribute(type, data),                    ///添加属性number
             new XElement(attribute, data)                     ///添加元素Name
             );
                    ///添加节点到文件中，并保存
                    xe.Add(student);
                    xe.Save(applocal + fine);
                }
            }
            catch (Exception)
            {
                if (MessageBox.Show("配置文件在读取时发发生了错误，是否要删除原来的配置文件再新生成一个？", "配置文件错误", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CreateFile(fine, 0);
                    write(fine, type, attribute, data);
                }
            }
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="fine">文件名</param>
        /// <param name="type">类型名</param>
        /// <param name="attribute">属性名</param>
        public void Remove(string fine, string type,string attribute)//删除XML文件中的元素
        {
            if (File.Exists(applocal + fine) == false)
            {
                CreateFile(fine, 0);//创建该文件，如果路径文件夹不存在，则报错。
            }
            ///导入XML文件
            XElement xe = XElement.Load(applocal + fine);
            ///查找被删除的元素
            IEnumerable<XElement> element = from e in xe.Elements()
                                            where e.Attribute(type).Value == attribute
                                            select e;
            ///删除指定的元素，并保存
            if (element.Count() > 0)
            {
                element.First().Remove();
            }
            xe.Save(applocal + fine);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="fine">文件名</param>
        /// <param name="type">类型名</param>
        /// <param name="attribute">属性名</param>
        public string read(string fine, string type, string attribute)
        {
            string temp = null;
            if (File.Exists(applocal + fine) == false)
            {
                CreateFile(fine, 0);//创建该文件，如果路径文件夹不存在，则报错。
            }
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(applocal + fine);

                XmlNode xnP = xmlDoc.SelectSingleNode("config/config[@" + type + "='" + attribute + "']/" + attribute);
                temp = xnP.InnerText;
                if (temp == "") temp = null;
            }
            catch (Exception)
            { }
            return temp;
        }
    }
}
