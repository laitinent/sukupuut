using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace Sukupuut
{
    public class Sukupuu
    {
        List<Henkilö> jäsenet = new List<Henkilö>();

        private static Sukupuu mInstance;

        private Sukupuu()
        {

        }

        public static Sukupuu getInstance()
        {
            if (mInstance == null)
            {
                mInstance = new Sukupuu();
            }
            return mInstance;
        }

        /// <summary>
        /// Add Henkilö to sukupuu
        /// </summary>
        /// <param name="henkilö"></param>
        /// <returns>Index on list</returns>
        public int Add(Henkilö henkilö)
        {
            int retval = jäsenet.Count;
            jäsenet.Add(henkilö);
            return retval;
        }

        public List<Henkilö> GetAll()
        {
            return jäsenet;
        }

        /// <summary>
        /// Find index of Henkilö in list
        /// </summary>
        /// <param name="eka"></param>
        /// <returns>Index (int)</returns>
        public int Find(Henkilö eka)
        {                        
            return jäsenet.IndexOf(eka);            
        }

        /// <summary>
        /// Replace eka with uusi
        /// </summary>
        /// <param name="eka">One to replace in list</param>
        /// <param name="uusi">New contents</param>
        public void Replace(Henkilö eka, Henkilö uusi)
        {
            jäsenet[Find(eka)] = uusi;
            
        }

        /// <summary>
        /// Load from local storage
        /// </summary>
        /// <param name="fileName">Filename used</param>
        public async void Load(string fileName)
        {
            /*var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values["sukupuu"] != null)
            {
                jäsenet = (List<Henkilö>)localSettings.Values["sukupuu"];
            }*/
            try
            {                
                var Serializer = new DataContractSerializer(typeof(List<Henkilö>));
                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName))
                {
                    
                    jäsenet = (List<Henkilö>)Serializer.ReadObject(stream);
                }
                /*
                using (var inputStream = stream.GetInputStreamAt(0))
                //using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(inputStream, new XmlDictionaryReaderQuotas()))
                    {
                        DataContractSerializer ser = new DataContractSerializer(typeof(List<Henkilö>));
                        //using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName))
                        {
                            // Deserialize the data and read it from the instance.
                            jäsenet = (List<Henkilö>)ser.ReadObject(reader, true);
                        }
                    }
                    //reader.Close();
                }
                //fs.Close();*/
            }
            catch (FileNotFoundException e) { Debug.WriteLine("Tiedostoa ei löydy: "+e.Message); }
            catch (XmlException e2) { Debug.WriteLine("XML tiedostossa virhe: "+e2.Message); }
        }

        /// <summary>
        /// Save as local storage
        /// </summary>
        /// <param name="fileName">Filename to use</param>
        public async void Save(string fileName)
        {
            //var localSettings = Windows.Storage.ApplicationData.Current.LocalFolder;
            //localSettings.Values["sukupuu"] = jäsenet;
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            var stream = await sampleFile.OpenAsync(FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(0))
            //using (FileStream writer = new FileStream(fileName, FileMode.Create))            
            {
                DataContractSerializer ser =  new DataContractSerializer(typeof(List<Henkilö>));
                ser.WriteObject(outputStream.AsStreamForWrite(), jäsenet); // was writer

                await outputStream.FlushAsync();
                await stream.FlushAsync();
            }
            stream.Dispose();
            //writer.Close();
        }
    }
}
