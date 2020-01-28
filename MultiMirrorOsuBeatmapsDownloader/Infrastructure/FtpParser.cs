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
        public List<SongsInfo> SongsList
        { 
            get; 
            private set; 
        }

        public async Task Parse(string query)
        {
            var songsArray = query.Split('\n').ToList();
            for (int i = 0; i < songsArray.Count; i++)
            {
                songsArray[i] = new string(songsArray[i].TrimEnd('\r').Skip(5).ToArray());
                var songToAdd = songsArray[i].Split(new char[] { ' ' }, 2).ToArray();
                if (songToAdd.Length > 1)
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

        public List<SongsInfo> RetrieveSongsList()
        {
            return SongsList;
        }
    }
}
