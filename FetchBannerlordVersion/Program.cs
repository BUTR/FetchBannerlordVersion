﻿using CommandLine;

using FetchBannerlordVersion.Options;

using System;

namespace FetchBannerlordVersion
{
    public static partial class Program
    {
        public static void Main(string[] args) => Parser
            .Default
            .ParseArguments<VersionTypeOptions, VersionOptions, ChangeSetOptions>(args)
            .WithParsed<VersionTypeOptions>(o =>
            {
                try
                {
                    Console.WriteLine(GetVersionType(o.Directory, o.Library).ToString());
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                    Environment.Exit(1);
                }
            })
            .WithParsed<VersionOptions>(o =>
            {
                try
                {
                    Console.WriteLine(GetVersion(o.Directory, o.Library));
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                    Environment.Exit(1);
                }
            })
            .WithParsed<ChangeSetOptions>(o =>
            {
                try
                {
                    Console.WriteLine(GetChangeSet(o.Directory, o.Library).ToString());
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                    Environment.Exit(1);
                }
            })
            .WithNotParsed(e =>
            {
                Console.Error.WriteLine(e.ToString());
                Environment.Exit(1);
            });
    }
}