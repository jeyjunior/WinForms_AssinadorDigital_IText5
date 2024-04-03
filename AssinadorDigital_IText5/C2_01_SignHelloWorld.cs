using iTextSharp.text.pdf.security;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.X509;
using iTextSharp.text;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;

namespace WinForms_AssinadorDigital_IText5
{
    public class C2_01_SignHelloWorld
    {
        //  Test certificates: https://docs.lacunasoftware.com/pt-br/articles/pki-guide/test-certs.html
        public const String KEYSTORE = @"C:\test-certs\Alan Mathison Turing.pfx";
        public static char[] PASSWORD = "1234".ToCharArray();
        public const String SRC = @"C:\test-filesToSign\001.pdf";
        public const String DEST_1 = @"C:\test-filesSigned\001_signed_SHA256.pdf";
        public const String DEST_2 = @"C:\test-filesSigned\001_signed_SHA512.pdf";
        public const String DEST_3 = @"C:\test-filesSigned\001_signed_SHA384.pdf";
        public const String DEST_4 = @"C:\test-filesSigned\001_signed_RIPEMD160.pdf";


        public void SignTest()
        {
            Pkcs12Store store = new Pkcs12Store(new FileStream(KEYSTORE, FileMode.Open), PASSWORD);
            String alias = "";
            ICollection<X509Certificate> chain = new List<X509Certificate>();
            // searching for private key

            foreach (string al in store.Aliases)
                if (store.IsKeyEntry(al) && store.GetKey(al).Key.IsPrivate)
                {
                    alias = al;
                    break;
                }

            AsymmetricKeyEntry pk = store.GetKey(alias);
            foreach (X509CertificateEntry c in store.GetCertificateChain(alias))
                chain.Add(c.Certificate);

            RsaPrivateCrtKeyParameters parameters = pk.Key as RsaPrivateCrtKeyParameters;
            C2_01_SignHelloWorld app = new C2_01_SignHelloWorld();
            app.Sign(SRC, String.Format(DEST_1, 1), chain, parameters, DigestAlgorithms.SHA256,
                     CryptoStandard.CMS, "Test 1", "Ghent");
            app.Sign(SRC, String.Format(DEST_2, 2), chain, parameters, DigestAlgorithms.SHA512,
                     CryptoStandard.CMS, "Test 2", "Ghent");
            app.Sign(SRC, String.Format(DEST_3, 3), chain, parameters, DigestAlgorithms.SHA384,
                     CryptoStandard.CADES, "Test 3", "Ghent");
            app.Sign(SRC, String.Format(DEST_4, 4), chain, parameters, DigestAlgorithms.RIPEMD160,
                     CryptoStandard.CADES, "Test 4", "Ghent");
        }

        public void Sign(String src, String dest, ICollection<X509Certificate> chain, ICipherParameters pk,
                 String digestAlgorithm, CryptoStandard subfilter, String reason, String location)
        {
            // Creating the reader and the stamper
            PdfReader reader = new PdfReader(src);
            FileStream os = new FileStream(dest, FileMode.Create);
            PdfStamper stamper = PdfStamper.CreateSignature(reader, os, '\0');
            // Creating the appearance
            PdfSignatureAppearance appearance = stamper.SignatureAppearance;
            appearance.Reason = reason;
            appearance.Location = location;
            appearance.SetVisibleSignature(new Rectangle(36, 748, 144, 780), 1, "sig");
            // Creating the signature
            IExternalSignature pks = new PrivateKeySignature(pk, digestAlgorithm);
            MakeSignature.SignDetached(appearance, pks, chain, null, null, null, 0, subfilter);
        }
    }
}
