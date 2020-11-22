using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii
{
    public class MegviiHttpTools
    {

        #region 字典转成字符串
        /// <summary>
        /// 字典转成字符串
        /// </summary>
        /// <param name="dict">待转化的对象</param>
        /// <returns></returns>
        public static string DictionaryToString(Dictionary<string, string> dict)
        {
            StringBuilder buffer = new StringBuilder();
            int i = 0;
            foreach (string key in dict.Keys)
            {
                if (i > 0)
                {
                    buffer.AppendFormat("&{0}={1}", key, dict[key]);
                }
                else
                {
                    buffer.AppendFormat("{0}={1}", key, dict[key]);
                }
                i++;
            }
            return buffer.ToString();
        }
        #endregion

        #region 对象转成字典
        /// <summary>
        /// 对象转换为字典
        /// </summary>
        /// <param name="obj">待转化的对象</param>
        /// <returns></returns>
        public static Dictionary<string, string> ObjectToDictionary(object obj)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

            foreach (PropertyInfo p in pi)
            {
                MethodInfo m = p.GetGetMethod();

                if (m != null && m.IsPublic)
                {
                    // 进行判NULL处理
                    if (m.Invoke(obj, new object[] { }) != null)
                    {
                        map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString()); // 向字典添加元素
                    }
                }
            }
            return map;
        }
        #endregion


        #region 旷视


        /// <summary>
        /// 带cookie的Get请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string HttpGetWithCookie(string Url, string postDataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string retString = "";
            try
            {

                request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                if (cookie.Count == 0)
                {
                    request.CookieContainer = new CookieContainer();
                    cookie = request.CookieContainer;
                }
                else
                {
                    request.CookieContainer = cookie;
                }
                request.AllowAutoRedirect = false;
                request.UserAgent = DefaultUserAgent;
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string errorMessage = sr.ReadToEnd();
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                if (response != null)
                    response.Close();
                if (request != null)
                    request.Abort();
            }
            return retString;
        }



        public class MsMultiPartFormData
        {
            private List<byte> formData;
            public String Boundary = "---------------------------7db1851cd1158";
            private String fieldName = "Content-Disposition: form-data; name=\"{0}\"";
            private String fileContentType = "Content-Type: {0}";
            private String fileField = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"";
            private Encoding encode = Encoding.GetEncoding("UTF-8");
            public MsMultiPartFormData()
            {
                formData = new List<byte>();
            }
            public void AddFormField(String FieldName, String FieldValue)
            {
                String newFieldName = fieldName;
                newFieldName = string.Format(newFieldName, FieldName);
                formData.AddRange(encode.GetBytes("--" + Boundary + "\r\n"));
                formData.AddRange(encode.GetBytes(newFieldName + "\r\n\r\n"));
                formData.AddRange(encode.GetBytes(FieldValue + "\r\n"));
            }
            public void AddFile(String FieldName, String FileName, byte[] FileContent, String ContentType)
            {
                String newFileField = fileField;
                String newFileContentType = fileContentType;
                newFileField = string.Format(newFileField, FieldName, FileName);
                newFileContentType = string.Format(newFileContentType, ContentType);
                formData.AddRange(encode.GetBytes("--" + Boundary + "\r\n"));
                formData.AddRange(encode.GetBytes(newFileField + "\r\n"));
                formData.AddRange(encode.GetBytes(newFileContentType + "\r\n\r\n"));
                formData.AddRange(FileContent);
                formData.AddRange(encode.GetBytes("\r\n"));
            }
            public void AddStreamFile(String FieldName, String FileName, byte[] FileContent, string ContentType = "application/octet-stream")
            {
                AddFile(FieldName, FileName, FileContent, "application/octet-stream");
            }
            public void PrepareFormData()
            {
                formData.AddRange(encode.GetBytes("--" + Boundary + "--"));
            }
            public List<byte> GetFormData()
            {
                return formData;
            }



        }

        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";


        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }

        public static string HttpPostWithCookieFace(IDictionary<string, string> parameters, string url, ref CookieContainer cookie)
        {

            string dicParam = string.Empty;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                dicParam = JsonConvert.SerializeObject(parameters);
                Encoding charset = Encoding.GetEncoding("utf-8");

                //HTTPSQ请求  
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;

                if (cookie.Count == 0)
                {
                    request.CookieContainer = new CookieContainer();
                    cookie = request.CookieContainer;
                }
                else
                {
                    request.CookieContainer = cookie;
                }
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Koala Admin";
                request.Timeout = 5 * 60 * 1000;
                //如果需要POST数据     
                if (!(parameters == null || parameters.Count == 0))
                {
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    foreach (string key in parameters.Keys)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        }
                        i++;
                    }
                    byte[] data = charset.GetBytes(buffer.ToString());
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                response = request.GetResponse() as HttpWebResponse;
                cookie.Add(response.Cookies);
                Stream streamRet = response.GetResponseStream();   //获取响应的字符串流  
                StreamReader sr = new StreamReader(streamRet); //创建一个stream读取流  
                string ret = sr.ReadToEnd();
                response.Close();

                return ret;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string errorMessage = sr.ReadToEnd();

                return "";
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (response != null)
                    response.Close();
                if (request != null)
                    request.Abort();
            }
        }


        /// <summary>
        /// 旷视专用
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="apiUrl"></param>
        /// <param name="fileInfos">附件信息 (filepath,filename)</param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string HttpPostHasAttachmentsWithCookieFace(IDictionary<string, string> dict, string apiUrl, IDictionary<string, string> fileInfos, ref CookieContainer cookie)
        {
            string ret = null;
            try
            {
                var request = WebRequest.Create(apiUrl) as HttpWebRequest;
                SetHeaderValue(request.Headers, "User-Agent", DefaultUserAgent);
                MsMultiPartFormData form = new MsMultiPartFormData();
                request.UserAgent = "Koala Admin";
                if (cookie.Count == 0)
                {
                    request.CookieContainer = new CookieContainer();
                    cookie = request.CookieContainer;
                }
                else
                {
                    request.CookieContainer = cookie;
                }


                if (null != dict)
                {
                    foreach (var d in dict)
                    {
                        form.AddFormField(d.Key, d.Value);
                    }
                }

                if (null != fileInfos)
                {
                    foreach (var f in fileInfos)
                    {
                        FileStream file = new FileStream(f.Key, FileMode.Open);
                        byte[] bb = new byte[file.Length];
                        file.Read(bb, 0, (int)file.Length);
                        file.Close();
                        form.AddStreamFile("photo", f.Value, bb, "image/jpeg");
                    }
                }

                form.PrepareFormData();
                request.ContentType = "multipart/form-data; boundary=" + form.Boundary;
                request.Timeout = 300000;
                request.Method = WebRequestMethods.Http.Post;
                Stream stream = request.GetRequestStream();
                foreach (var b in form.GetFormData())
                {
                    stream.WriteByte(b);
                }
                stream.Close();
                WebResponse response = request.GetResponse();

                var streamResponse = response.GetResponseStream();

                if (streamResponse != null)
                {
                    var reader = new StreamReader(streamResponse);

                    ret = reader.ReadToEnd();
                }
                return ret;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string errorMessage = sr.ReadToEnd();

                return "";
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {

            }
        }



        /// <summary>
        /// 品质看板运营流程专用
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="apiUrl"></param>
        /// <param name="fileInfos">附件信息 (filepath,filename)</param>
        /// <returns></returns>
        public static string HttpPostQualityKanbanOperation(IDictionary<string, string> dict, string apiUrl, IDictionary<string, string> fileInfos)
        {
            string ret = null;
            try
            {
                var request = WebRequest.Create(apiUrl) as HttpWebRequest;
                MsMultiPartFormData form = new MsMultiPartFormData();
                if (null != dict)
                {
                    foreach (var d in dict)
                    {
                        form.AddFormField(d.Key, d.Value);
                    }
                }

                if (null != fileInfos)
                {
                    foreach (var f in fileInfos)
                    {
                        FileStream file = new FileStream(f.Key, FileMode.Open);
                        byte[] bb = new byte[file.Length];
                        file.Read(bb, 0, (int)file.Length);
                        file.Close();
                        form.AddStreamFile("fish_file", f.Value, bb, "application/octet-stream");
                    }
                }

                form.PrepareFormData();
                request.ContentType = "multipart/form-data; boundary=" + form.Boundary;
                request.Timeout = 300000;
                request.Method = WebRequestMethods.Http.Post;
                Stream stream = request.GetRequestStream();
                foreach (var b in form.GetFormData())
                {
                    stream.WriteByte(b);
                }
                stream.Close();
                WebResponse response = request.GetResponse();

                var streamResponse = response.GetResponseStream();

                if (streamResponse != null)
                {
                    var reader = new StreamReader(streamResponse);

                    ret = reader.ReadToEnd();
                }

                return ret;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                try
                {
                    StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                    string errorMessage = sr.ReadToEnd();

                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string HttpUploadFileFaceCheck(string url, string path, CookieContainer cc)
        {
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                request.CookieContainer = cc;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
                request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
                byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                int pos = path.LastIndexOf("/");
                string fileName = path.Substring(pos + 1);

                //请求头部信息 
                StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"photo\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
                byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] bArr = new byte[fs.Length];
                fs.Read(bArr, 0, bArr.Length);
                fs.Close();

                Stream postStream = request.GetRequestStream();
                postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                postStream.Write(bArr, 0, bArr.Length);
                postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                postStream.Close();

                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                var mes = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 旷视人脸验证
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="parameters"></param>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static string HttpUploadFileByteFaceCheck(string url, byte[] path, string fileName, IDictionary<string, string> parameters, CookieContainer cookie)
        {
            string ret = null;

            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                SetHeaderValue(request.Headers, "User-Agent", DefaultUserAgent);
                MsMultiPartFormData form = new MsMultiPartFormData();
                request.UserAgent = "Koala Admin";
                if (cookie.Count == 0)
                {
                    request.CookieContainer = new CookieContainer();
                    cookie = request.CookieContainer;
                }
                else
                {
                    request.CookieContainer = cookie;
                }


                if (null != parameters)
                {
                    foreach (var d in parameters)
                    {
                        form.AddFormField(d.Key, d.Value);
                    }
                }

                form.AddStreamFile("photo", fileName, path);

                form.PrepareFormData();
                request.ContentType = "multipart/form-data; boundary=" + form.Boundary;
                request.Timeout = 300000;
                request.Method = WebRequestMethods.Http.Post;
                Stream stream = request.GetRequestStream();
                foreach (var b in form.GetFormData())
                {
                    stream.WriteByte(b);
                }
                stream.Close();
                WebResponse response = request.GetResponse();

                var streamResponse = response.GetResponseStream();

                if (streamResponse != null)
                {
                    var reader = new StreamReader(streamResponse);

                    ret = reader.ReadToEnd();
                }

                return ret;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string errorMessage = sr.ReadToEnd();

                return "";
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {

            }
        }


        public static string HttpDeleteWithCookie(IDictionary<string, string> parameters, string url, ref CookieContainer cookie)
        {

            string dicParam = string.Empty;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                dicParam = JsonConvert.SerializeObject(parameters);
                Encoding charset = Encoding.GetEncoding("utf-8");

                //HTTPSQ请求  
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;

                if (cookie.Count == 0)
                {
                    request.CookieContainer = new CookieContainer();
                    cookie = request.CookieContainer;
                }
                else
                {
                    request.CookieContainer = cookie;
                }
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "DELETE";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = DefaultUserAgent;
                //如果需要POST数据     
                if (!(parameters == null || parameters.Count == 0))
                {
                    StringBuilder buffer = new StringBuilder();
                    int i = 0;
                    foreach (string key in parameters.Keys)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        }
                        i++;
                    }
                    byte[] data = charset.GetBytes(buffer.ToString());
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                response = request.GetResponse() as HttpWebResponse;
                Stream streamRet = response.GetResponseStream();   //获取响应的字符串流  
                StreamReader sr = new StreamReader(streamRet); //创建一个stream读取流  
                string ret = sr.ReadToEnd();
                response.Close();

                return ret;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string errorMessage = sr.ReadToEnd();

                return "";
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                response?.Close();
                request?.Abort();
            }
        }

        #endregion
    }
}
