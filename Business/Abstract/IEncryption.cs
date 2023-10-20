using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;
public interface IEncryption {
    string EncryptString(string plainText);
    string DecryptString(string cipherText);
}
