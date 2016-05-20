// <copyright company="eXtensoft, LLC" file="RemoteDesktop.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public static class RemoteDesktop
    {
        public static void Connect(string serverIP, string username, string password)
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            p.StartInfo.Arguments = "/generic:TERMSRV/" + serverIP + " /user: " + username + " /pass:" + password;
            p.Start();

            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            p.StartInfo.Arguments = "/v " + serverIP;
            p.Start();
        }

        public static void Connect(string serverIP)
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            p.StartInfo.Arguments = "/generic:TERMSRV/";
            p.Start();

            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            p.StartInfo.Arguments = "/v " + serverIP;
            p.Start();
        }

    }

}
