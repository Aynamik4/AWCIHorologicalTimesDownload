namespace AWCIHorologicalTimesDownload;

enum Month
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}

internal class Program
{
    static async Task Main(string[] args)
    {
        var downloadEngine = new DownloadEngine();

        for (int i = 2010; i < 2013; i++)
        {
            string fileName = "";
            string outFileName = "";

            for (int m = (int)Month.January; m < 12; m++)
            {
                fileName = $"{(Month)m}{i}.pdf";
                outFileName = $"{i}-{(m + 1).ToString().PadLeft(2, '0')}-web.pdf";
                Console.WriteLine(outFileName);

                await downloadEngine.DownloadAndSave
                    ($"https://www.awci.com/wp-content/uploads/ht/{fileName}",
                    // https://www.awci.com/wp-content/uploads/ht/January2013.pdf // Download manually!
                    "C:\\TMP5",
                    outFileName
                    );
            }
        }
    }
}
