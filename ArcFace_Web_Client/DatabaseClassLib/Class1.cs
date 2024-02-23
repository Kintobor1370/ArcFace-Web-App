using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Database
{
    //______________________________________________________PERSISTENT STORAGE ATTRIBUTES_____________________________________________________
    public class Image
    {
        [Key]
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public byte[] Data
        {
            get;
            set;
        }
        public string Hash 
        {
            get;
            set;
        }
        public byte[] Embedding
        { 
            get;
            set;
        }

        // Creating hash-code based on the image's absolute path
        public static string GetHash(string image_path)
        {
            byte[] image_data = File.ReadAllBytes(image_path);
            using (var sha256 = SHA256.Create())
            {
                return string.Concat(
                    sha256.ComputeHash(image_data).Select(x => x.ToString("X2"))
                    );
            }
        }

        // Creating hash-code from the image's byte array
        public static string GetHash(byte[] image_data)
        {
            using (var sha256 = SHA256.Create())
            {
                return string.Concat(
                    sha256.ComputeHash(image_data).Select(x => x.ToString("X2"))
                    );
            }
        }
    }

    public class Converters
    {
        // float[] -> byte[] and byte[] -> float[] converters
        // used to encode and decode Embeddings vector so that it could be kept in storage
        public static byte[] FloatToByte(float[] FloatArray)
        {
            byte[] ByteArray = new byte[FloatArray.Length * 4];
            Buffer.BlockCopy(FloatArray, 0, ByteArray, 0, ByteArray.Length);
            return ByteArray;
        }
        public static float[] ByteToFloat(byte[] ByteArray)
        {
            float[] FloatArray = new float[ByteArray.Length / 4];
            Buffer.BlockCopy(ByteArray, 0, FloatArray, 0, ByteArray.Length);
            return FloatArray;
        }
    }

    public class Context : DbContext
    {
        public DbSet<Image> Images
        {
            get;
            set;
        }
        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder o) => o.UseSqlite("Data Source=ImageEmbeddings.db");
    }

    public class PostData
    {
        public string Name
        {
            get;
            set;
        }
        public string Base64String
        {
            get;
            set;
        }
    }
}