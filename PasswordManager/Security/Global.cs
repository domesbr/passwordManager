using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Encryption
{
    class Global
    {
        /* REF http://eddiejackson.net/wp/?p=13434 */
        public const String strPermutation = "wcawiuivpaqijbd";
        public const Int32 bytePermutation1 = 0x19;
        public const Int32 bytePermutation2 = 0x59;
        public const Int32 bytePermutation3 = 0x17;
        public const Int32 bytePermutation4 = 0x41;
    }
}
