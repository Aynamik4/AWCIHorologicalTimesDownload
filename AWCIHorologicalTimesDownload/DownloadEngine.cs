using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCIHorologicalTimesDownload;
internal class DownloadEngine
{
    public async Task DownloadAndSave(string sourceFile, string destinationFolder, string destinationFileName)
    {
        Stream fileStream = await GetFileStream(sourceFile);

        if (fileStream != Stream.Null)
        {
            await SaveStream(fileStream, destinationFolder, destinationFileName);
        }
    }

    async Task<Stream> GetFileStream(string fileUrl)
    {
        HttpClient httpClient = new HttpClient();
        try
        {
            Stream fileStream = await httpClient.GetStreamAsync(fileUrl);
            return fileStream;
        }
        catch (Exception ex)
        {
            return Stream.Null;
        }
    }

    static async Task SaveStream(Stream fileStream, string destinationFolder, string destinationFileName)
    {
        if (!Directory.Exists(destinationFolder))
            Directory.CreateDirectory(destinationFolder);

        string path = Path.Combine(destinationFolder, destinationFileName);

        using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
        {
            await fileStream.CopyToAsync(outputFileStream);
        }
    }
}
