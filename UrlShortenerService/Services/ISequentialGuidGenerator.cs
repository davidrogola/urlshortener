using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace UrlShortenerService.Services
{
    public interface ISequentialGuidGenerator
    {
        Guid New();
    }

    public class SequentialGuidGenerator : ISequentialGuidGenerator
    {
        public Guid New()
        {
            Guid guid;
            UuidCreateSequential(out guid);
            var s = guid.ToByteArray();
            var t = new byte[16];

            t[3] = s[0];
            t[2] = s[1];
            t[1] = s[2];
            t[0] = s[3];
            t[5] = s[4];
            t[4] = s[5];
            t[7] = s[6];
            t[6] = s[7];
            t[8] = s[8];
            t[9] = s[9];
            t[10] = s[10];
            t[11] = s[11];
            t[12] = s[12];
            t[13] = s[13];
            t[14] = s[14];
            t[15] = s[15];
            return new Guid(t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid">An out parameter that is passed by reference.</param>
        /// <returns>Three posssible values; RPDS_S_OK, RPC_S_UUID_LOCAL_ONLY and RPC_S_UUID_NO_ADDRESS </returns>
        [DllImport("Rpcrt4.dll", SetLastError = false)]
        private extern static int UuidCreateSequential(out Guid guid);
    }
}