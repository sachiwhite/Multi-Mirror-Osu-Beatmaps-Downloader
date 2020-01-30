using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiMirrorOsuBeatmapsDownloader.Model;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public class FtpParser : IParser
    {
        private readonly IFtpLoader ftpLoader;
        public FtpParser(IFtpLoader ftpLoader)
        {
            this.ftpLoader = ftpLoader;
            SongsList = new List<SongsInfo>();
        }
        public List<SongsInfo> SongsList
        { 
            get; 
            private set; 
        }
        /// <summary>
        /// method to parse results from FTP server
        /// </summary>
        /// <param name="query"> search criteria </param>
        /// <returns></returns>
        public async Task Parse(string query)
        {
            var data = await ftpLoader.GetContent();
            var songsArray = data.Split('\n').ToList();
            for (int i = 0; i < songsArray.Count; i++)
            {
                songsArray[i] = new string(songsArray[i].TrimEnd('\r').Skip(5).ToArray());
                var songToAdd = songsArray[i].Split(new char[] { ' ' }, 2).ToArray();
                if (songToAdd.Length > 1 && songToAdd[1].Contains(query))
                {
                    SongsList.Add(
                        new SongsInfo(
                            songToAdd[1],
                            string.Format("//b.ppy.sh/thumb/{0}l.jpg", songToAdd[0]),
                            string.Format("ftp//gildiagrzybiarzy.pl/osu!/{0} {1}.osz",
                            songToAdd[0], songToAdd[1])
                            )
                        );
                    
                }
                   
            }
        }

        public List<SongsInfo> RetrieveSongsList(string query="")
        {
            return SongsList;
            return SongsList.Where(s=> s.Title.Contains(query)).ToList();
        }
    }
}
