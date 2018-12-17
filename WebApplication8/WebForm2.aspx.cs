using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication8
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Str = TextBox1.Text.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);

            if (isNum)
                Response.Write("<br>" + "คำตอบ:" + NumcTotext());
            else
                
                Response.Write("<br>" + "คำตอบ:" + textToNumc());
                
                
                

            //Response.Write("<br>" + "answer:" + textToNumc());
            //Response.Write("<br>" + "answer:" + NumcTotext());
                }

        public string NumcTotext()
        {
            string numtext = TextBox1.Text;
            string wordTxt, n, word = "";
            double amount;
            if (numtext == "")
                word = "โปรดกรอกแบบฟอร์มให้ถูกต้อง";
            else
            {
                amount = Convert.ToDouble(numtext);
                try { amount = Convert.ToDouble(numtext); }
                catch { amount = 0; }
                wordTxt = TextBox1.Text;
                string[][] th_num = new string[3][];
                string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };

                th_num[0] = new string[10] { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
                th_num[1] = new string[2] { "หนึ่ง", "เอ็ด" };
                th_num[2] = new string[2] { "สอง", "ยี่" };
                string[] temp = wordTxt.Split('.');
                string intVal = temp[0];
                string decVal = "";
                if (temp.Length > 1)
                    decVal = temp[1];
                int ln = intVal.Length;
                string[] th = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
                if (Convert.ToDouble(wordTxt) == 0)
                    word = "ศูนย์";
                else
                {
                    for (int i = ln; i > 0; i--)
                    {
                        int x = i - 1;
                        // Response.Write(intVal);
                        // return;
                        int o = Convert.ToInt32(intVal);
                        string l = o.ToString();
                        int k = l.Length;
                        int m = Convert.ToInt32(intVal.Substring(ln - i, 1));
                        int digit = x % 6;
                        if (m != 0)
                        {
                            if (m == 1)
                            {

                                word += (digit == 1) ? "" : th_num[1][digit == 0 && l.Length > 1 ? 1 : 0];
                                //ถ้า tem[0].length == 1  digit=0 m==1 ให้เลือก word += th_num[1][0] ให้อ่านรว่าหนึ่ง

                            }
                            else if (m == 2)
                            {
                                word = word + th_num[2][digit == 1 ? 1 : 0];
                            }
                            else
                            {
                                word += th_num[0][m];
                            }
                            word += rank[(digit == 0 && x > 0 ? 6 : digit)];
                        }
                        else
                        {
                            word += rank[digit == 0 && x > 0 ? 6 : 0];
                        }
                    }

                    if (temp.Length > 1)
                    {
                        if (decVal == "00")
                            word += "";
                        //else if (decVal == "0")
                        //    word += "";
                        else
                        {
                            word += "จุด";

                            for (int i = 0; i < decVal.Length; i++)
                            {
                                n = decVal.Substring(i, 1);
                                word += th[Convert.ToInt32(n)];

                            }

                        }
                    }

                }

            }

            //Label1.Text = word;

            return word;

        }

        public string textToNumc()
        {
           
            string[] numList = new string[9] { "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
            string[] numList2 = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] posList = new string[6] { "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] posList2 = new string[6] { "10", "100", "1000", "10000", "100000", "1000000" };
            string numText = TextBox1.Text;

            List<long> ans = new List<long>();
            string testtext = numText.ToString();
            //Response.Write(testtext + "<br>");
            string[] newtext = Regex.Split(testtext, "ล้าน");         //ตัด ล้านออก   

            for (int i = 0; i < newtext.Length; i++)
            {
                //Response.Write("<br>" + newtext[i] + "<br>");

                int idx = 0;

                foreach (string num in numList)
                {
                    newtext[i] = newtext[i].Replace(num, numList2[idx] + ",");
                    idx += 1;
                    //idx = idx + 1
                }
                newtext[i] = newtext[i].Replace("เอ็ด", "1" + ",");
                newtext[i] = newtext[i].Replace("ยี่", "2" + ",");
                //Response.Write(newtext[i] + "<br>");
                idx = 0;
                foreach (string pos in posList)
                {
                    newtext[i] = newtext[i].Replace(pos, posList2[idx] + "$");
                    idx += 1;
                }
                //Response.Write(newtext[i] + "<br>");

                int result = 0;
                string[] words = newtext[i].Split('$');
                if (words[0] == "0") { return "0"; }; 
                foreach (string word in words)
                {
                    //Response.Write(word + "<br>");

                    string[] numSet = word.Split(',');

                    //foreach (string num in numSet)
                    //{ Response.Write(num + "<br>"); };

                    try
                    {
                        result += Convert.ToInt32(numSet[0]) * Convert.ToInt32(numSet[1]);
                    }
                    catch
                    {
                        try
                        {
                            result += Convert.ToInt32(numSet[0]);
                        }
                        catch
                        {
                            //result += Convert.ToInt32(numSet[1]);                         
                        }
                    }
                }
                ans.Add(Convert.ToInt64(result * Math.Pow(1000000, newtext.Length - i - 1)));
                //Response.Write(ans[i]);
                //Response.Write(ans.ToString());               
            };
            string tob = "";
            tob = ans.Sum().ToString("#,##0");
            if (tob == "0" && testtext != "ศูนย์")
            {
                return "โปรดกรอกแบบฟอร์มให้ถูกต้อง";
            }
            else
                return tob;

            
            //Response.Write("<br>" + "answer:" + ans.Sum());
        }

      

            }
    
}