﻿using BUTR.NativeAOT.Shared;

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FetchBannerlordVersion.Native
{
    public static unsafe partial class Bindings
    {
        [UnmanagedCallersOnly(EntryPoint = "bfv_get_change_set", CallConvs = new[] { typeof(CallConvCdecl) })]
        public static return_value_uint32* GetChangeSet(param_string* p_game_folder_path, param_string* p_lib_assembly)
        {
            Logger.LogInput(p_game_folder_path, p_lib_assembly);
            try
            {
                var gameFolderPath = new string(param_string.ToSpan(p_game_folder_path));
                var libAssembly = new string(param_string.ToSpan(p_lib_assembly));

                var result = (uint) Fetcher.GetChangeSet(Path.GetFullPath(gameFolderPath), libAssembly);

                Logger.LogOutputPrimitive(result);
                return return_value_uint32.AsValue(result, false);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                return return_value_uint32.AsError(Utils.Copy(e.ToString(), false), false);
            }
        }

        [UnmanagedCallersOnly(EntryPoint = "bfv_get_version", CallConvs = new[] { typeof(CallConvCdecl) })]
        public static return_value_string* GetVersion(param_string* p_game_folder_path, param_string* p_lib_assembly)
        {
            Logger.LogInput(p_game_folder_path, p_lib_assembly);
            try
            {
                var gameFolderPath = new string(param_string.ToSpan(p_game_folder_path));
                var libAssembly = new string(param_string.ToSpan(p_lib_assembly));

                var result = Fetcher.GetVersion(Path.GetFullPath(gameFolderPath), libAssembly);

                Logger.LogOutput(result);
                return return_value_string.AsValue(Utils.Copy(result, false), false);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                return return_value_string.AsError(Utils.Copy(e.ToString(), false), false);
            }
        }

        [UnmanagedCallersOnly(EntryPoint = "bfv_get_version_type", CallConvs = new[] { typeof(CallConvCdecl) })]
        public static return_value_uint32* GetVersionType(param_string* p_game_folder_path, param_string* p_lib_assembly)
        {
            Logger.LogInput(p_game_folder_path, p_lib_assembly);
            try
            {
                var gameFolderPath = new string(param_string.ToSpan(p_game_folder_path));
                var libAssembly = new string(param_string.ToSpan(p_lib_assembly));

                var result = (uint) Fetcher.GetVersionType(Path.GetFullPath(gameFolderPath), libAssembly);

                Logger.LogOutputPrimitive(result);
                return return_value_uint32.AsValue(result, false);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                return return_value_uint32.AsError(Utils.Copy(e.ToString(), false), false);
            }
        }
    }
}