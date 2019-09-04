using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LJD.App.Util
{
    /// <summary>
    /// 通用方法
    /// </summary>
    public static class CommonHelper
    {  
        /// <summary>
        /// 输入一个字符串，返回该字符串的MD5值
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>返回值</returns>
        public static string GetMd5(string str)
        {
            StringBuilder sbMd5 = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffers = System.Text.Encoding.UTF8.GetBytes(str);
                byte[] bytesMd5 = md5.ComputeHash(buffers);
                for (int i = 0; i < bytesMd5.Length; i++)
                {
                    sbMd5.Append(bytesMd5[i].ToString("x2"));
                }
            }
            return sbMd5.ToString();
        }
        //C#加解密代码
        /// <summary>
        /// DES加密方法
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串</param>
        /// <param name="sKey">密匙(要8位)</param>
        /// <returns></returns>
        public static string DESEnCode(string pToEncrypt, string sKey)
        {
            //sKey = "qdswljd!";  //密匙
            // string pToEncrypt1 = HttpContext.Current.Server.UrlEncode(pToEncrypt);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="pToDecrypt">要加的字符串</param>
        /// <param name="sKey">密匙(要8位)</param>
        /// <returns></returns>
        public static string DESDeCode(string pToDecrypt, string sKey)
        {
            //sKey = "qdswljd!";
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        } 
        /// <summary>  
        /// 获取时间戳Timestamp    
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static int GetTimeStamp(DateTime dt)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }

        /// <summary>
        /// 金额转大写
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public static string NumGetStr(double Num)
        {
            string[] DX_SZ = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾" };//大写数字  
            string[] DX_DW = { "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "万" };
            string[] DX_XSDS = { "角", "分" };//大些小数单位  
            if (Num == 0) return DX_SZ[0];

            Boolean IsXS_bool = false;//是否小数  

            string NumStr;//整个数字字符串  
            string NumStr_Zs;//整数部分  
            string NumSr_Xs = "";//小数部分  
            string NumStr_R = "";//返回的字符串  


            NumStr = Num.ToString();
            NumStr_Zs = NumStr;
            if (NumStr_Zs.Contains("."))
            {
                NumStr = Math.Round(Num, 2).ToString();
                NumStr_Zs = NumStr.Substring(0, NumStr.IndexOf("."));
                NumSr_Xs = NumStr.Substring((NumStr.IndexOf(".") + 1), (NumStr.Length - NumStr.IndexOf(".") - 1));
                IsXS_bool = true;
            }

            int k = 0;
            Boolean IsZeor = false;//整数中间连续0的情况  
            for (int i = 0; i < NumStr_Zs.Length; i++) //整数  
            {
                int j = int.Parse(NumStr_Zs.Substring(i, 1));
                if (j != 0)
                {
                    NumStr_R += DX_SZ[j] + DX_DW[NumStr_Zs.Length - i - 1];
                    IsZeor = false; //没有连续0  
                }
                else if (j == 0)
                {
                    k++;
                    if (!IsZeor && !(NumStr_Zs.Length == i + 1)) //等于0不是最后一位，连续0取一次  
                    {
                        //有问题  
                        if (NumStr_Zs.Length - i - 1 >= 4 && NumStr_Zs.Length - i - 1 <= 6)
                            NumStr_R += DX_DW[4] + "零";
                        else
                            if (NumStr_Zs.Length - i - 1 > 7)
                            NumStr_R += DX_DW[8] + "零";
                        else
                            NumStr_R += "零";

                        IsZeor = true;
                    }

                    if (NumStr_Zs.Length == i + 1)//  等于0且是最后一位 变成 XX元整  
                        NumStr_R += DX_DW[NumStr_Zs.Length - i - 1];
                }

            }
            if (NumStr_Zs.Length > 2 && k == NumStr_Zs.Length - 1)
                NumStr_R = NumStr_R.Remove(NumStr_R.IndexOf('零'), 1); //比如1000，10000元整的情况下 去0  

            if (!IsXS_bool) return NumStr_R + "整"; //如果没有小数就返回  
            else
            {
                for (int i = 0; i < NumSr_Xs.Length; i++)
                {
                    int j = int.Parse(NumSr_Xs.Substring(i, 1));
                    NumStr_R += DX_SZ[j] + DX_XSDS[NumSr_Xs.Length - i - 1];
                }
            }

            return NumStr_R;
        }
        /// <summary>
        /// 判断字符串是不是GUID
        /// </summary>
        /// <param name="strSrc"></param>
        /// <returns></returns>
        public static bool IsGuidByParse(string strSrc)
        {
            Guid g = Guid.Empty;
            return Guid.TryParse(strSrc, out g);
        }

    }
   

}
