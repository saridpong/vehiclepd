using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodev.Framework.Security
{
    public class UrlCryptography
    {
        private string _url = "";
        private string _tmpUrl = "";
        private char _charSplitUrl = '&';
        private char _charSplitParam = '=';

        private Hashtable ht = new Hashtable();

        //log4net logger.
        public static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public string URL
        {
            set
            {
                _url = value;
                if (_url == null)
                    _url = "";
                //call once after URL is set.
                try
                {
                    GenerateUrl(this._charSplitUrl, this._charSplitParam);
                }
                catch (UrlCryptoException e)
                {
                    log.Warn(string.Format("Extract decrypt url error url={0}, _charSplitUrl={1}, _charSplitParam={2}", _url, this._charSplitUrl, this._charSplitParam), e);
                }
            }
            get
            {
                return _url;
            }
        }
        public char CharSplitURL
        {
            set
            {
                this._charSplitUrl = value;
            }
            get
            {
                return this._charSplitUrl;
            }
        }
        public char CharSplitParameterURL
        {
            set
            {
                this._charSplitParam = value;
            }
            get
            {
                return this._charSplitParam;
            }
        }
        public string EncryptUrl(string url)
        {
            this._url = url;
            return EncryptUrl();
        }
        public string EncryptUrl()
        {
            Cryptography ctg = new Cryptography();
            string strUrl = "";
            if (!_url.Equals(""))
            {
                strUrl = ctg.Encrypt(_url);
                strUrl = System.Web.HttpUtility.UrlEncode(strUrl);
            }
            else
            {
                strUrl = "";
            }
            return strUrl;
        }
        public string DecryptUrl(string url)
        {
            this._url = url;
            return DecryptUrl();
        }
        public string DecryptUrl()
        {
            Cryptography ctg = new Cryptography();
            string strUrl = "";
            if (!_url.Equals(""))
            {
                strUrl = ctg.Decrypt(_url);
            }
            else
            {
                strUrl = "";
            }
            return strUrl;
        }

        private void GenerateUrl(char strSplit, char strSplitVal)
        {
            string strUrl = "";
            string[] strValue;
            string[] strTmp;
            Cryptography ctg = new Cryptography();
            strUrl = _url;
            string strKey, strVal;
            if (!this._tmpUrl.Equals(this._url))
            {
                this._tmpUrl = this._url;
                if (!_url.Equals(""))
                {
                    strUrl = ctg.Decrypt(strUrl);
                    strValue = GetsPlitValue(strUrl, strSplit);
                    for (int i = 0; i < strValue.Length; i++)
                    {
                        //split key-value
                        //expected 2 length of string array
                        strTmp = GetsPlitValue(strValue[i], strSplitVal);
                        if (strTmp.Length == 2)
                        {
                            strKey = strTmp[0].ToString().Trim();
                            strVal = strTmp[1].ToString().Trim();
                        }
                        else
                        {   //put all sentence as key with empty value
                            strKey = strTmp[0].ToString().Trim();
                            strVal = string.Empty;
                        }
                        ht.Add(strKey, strVal);
                    }

                }
            }
            //			else
            //			{
            //				log.Warn(string.Format("GenerateUrl did nothing dueto {0} == {1}", _tmpUrl, _url));
            //			}

        }
        public string GetParameter(string param)
        {
            string val = "";

            //prevent null key.
            if (param == null)
                return val;

            //int v;
            try
            {
                //GenerateUrl(this._charSplitUrl,this._charSplitParam );

                //prevent null reference in case of nothing found in hash
                if (ht[param.Trim()] != null)
                {
                    val = ht[param.Trim()].ToString();
                }
            }
            catch (Exception)
            {
                //keep information for traking
                //log.Warn(string.Format("GetParameter/{0}/{1}/{2}", param, _url, _tmpUrl), ex);

                //
                //SHOULD RETURN EMPTY or throw an exception.
                //
                //Any call to this method expected the string in return. When the exception occured inside
                //and you always set the value to return string. This is a hard situation for checking the 
                //return again.
                //			
                //			TONG/ Mar 09,2006
                //val="";
            }

            return val;
        }

        private string[] GetsPlitValue(string str, char sepa)
        {
            char[] ch = new char[1];
            ch[0] = sepa;
            return str.Split(ch[0]);
        }
    }
}
