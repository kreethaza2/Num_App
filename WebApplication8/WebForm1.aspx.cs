using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication8
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string numtext = TextBox1.Text;
            string wordTxt, n, word = "";
            double amount;
            if (numtext == "")
                word = "Please Enter Correct F0rm";
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

                                word += (digit == 1) ?"" : th_num[1][digit == 0 && l.Length > 1 ? 1 : 0];
                                //ถ้า tem[0].length == 1  digit=0 m==1 ให้เลือก word += th_num[1][0] ให้อ่านรว่าหนึ่ง

                            }
                            else if (m == 2)
                            {
                                word =word + th_num[2][digit == 1 ? 1 : 0];
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

            Label1.Text = word;

        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

      

    }
}