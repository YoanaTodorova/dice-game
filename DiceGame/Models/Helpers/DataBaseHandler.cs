using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DiceGame.Models.Helpers
{
    public static class DataBaseHandler
    {
        static string dirpath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\DiceGame\\";
        public static List<User> GetUsers()
        {
            List<User> userslist = new List<User>();
            string text = "";

            if (File.Exists(dirpath + "UserData.db")) { text = File.ReadAllText(dirpath + "UserData.db"); }
            string[] lines = text.Split('\n');
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line.Trim()))
                {
                    User usr = new User();
                    string[] properties = line.Split('¤');
                    foreach (var property in properties)
                    {
                        if (!string.IsNullOrWhiteSpace(property.Trim()))
                        {
                            string[] values = property.Split('°');
                            if (values.Length > 1)
                            {
                                var prop = usr.GetType().GetProperties().Where(x => x.Name == values[0]).First();
                                switch(prop.PropertyType.Name.ToLower())
                                {
                                    case "int32":
                                        {
                                            int value = -1;
                                            if (Int32.TryParse(values[1], out value))
                                            {
                                                prop.SetValue(usr, value);
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            prop.SetValue(usr, values[1]);
                                            break;
                                        }
                                }
                                
                            }
                        }
                    }
                    userslist.Add(usr);
                }
            }

            return userslist;
        }

        public static bool SetUsers(List<User> userslist)
        {
            bool success = false;
            string datatofile = "";

            foreach (User usr in userslist)
            {
                foreach (var prop in usr.GetType().GetProperties())
                {
                    datatofile += string.Format("{0}°{1}¤", prop.Name, prop.GetValue(usr, null));
                }
                datatofile += Environment.NewLine;
            }
            
            if(!Directory.Exists(dirpath)) { Directory.CreateDirectory(dirpath); }
            File.WriteAllText(dirpath+"UserData.db", datatofile);

            return success;
        }
    }
}