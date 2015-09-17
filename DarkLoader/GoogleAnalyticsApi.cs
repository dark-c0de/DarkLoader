﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace DarkLoader
{
    public class GoogleAnalyticsApi
    {
        public static void TrackEvent(string category, string action, string label, int? value = null)
        {
            if (!Program.IsDebug)
            {
                try
                {
                    Track(HitType.@event, category, action, label, value);
                }
                catch(Exception){

                }
            }
        }

        public static void TrackPageview(string category, string action, string label, int? value = null)
        {
            if (!Program.IsDebug)
            {
                try
                {
                    Track(HitType.@pageview, category, action, label, value);
                }
                catch (Exception)
                {

                }
            }
        }

        private static void Track(HitType type, string category, string action, string label,
                                  int? value = null)
        {
            if (string.IsNullOrEmpty(category)) throw new ArgumentNullException("category");
            if (string.IsNullOrEmpty(action)) throw new ArgumentNullException("action");

            var request = (HttpWebRequest)WebRequest.Create("http://www.google-analytics.com/collect");
            request.Method = "POST";
            request.KeepAlive = false;

            // the request body we want to send
            var postData = new Dictionary<string, string>
                           {
                               { "v", "1" },
                               { "tid", "UA-67700554-1" },
                               { "cid", "555" },
                               { "t", type.ToString() },
                               { "ec", category },
                               { "ea", action },
                           };
            if (!string.IsNullOrEmpty(label))
            {
                postData.Add("el", label);
            }
            if (value.HasValue)
            {
                postData.Add("ev", value.ToString());
            }

            var postDataString = postData
                .Aggregate("", (data, next) => string.Format("{0}&{1}={2}", data, next.Key,
                                                             HttpUtility.UrlEncode(next.Value)))
                .TrimEnd('&');

            // set the Content-Length header to the correct value
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataString);

            // write the request body to the request
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(postDataString);
            }

            try
            {
                var webResponse = (HttpWebResponse)request.GetResponse();
                if (webResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpException((int)webResponse.StatusCode,
                                            "Google Analytics tracking did not return OK 200");
                }
                webResponse.Close();
            }
            catch (Exception)
            {
            }
        }

        private enum HitType
        {
            // ReSharper disable InconsistentNaming
            @event,
            @pageview,
            // ReSharper restore InconsistentNaming
        }
    }
}