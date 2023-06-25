namespace Zadania.Helpers
{
   using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SRTProcessor
{
    public class SubtitleProcessor
    {
        public void ProcessSubtitles(string inputFilePath, string outputFilePath1, string outputFilePath2, TimeSpan timeShift)
        {
            // Wczytaj zawartość pliku .SRT
            string[] lines = File.ReadAllLines(inputFilePath);
            List<SubtitleEntry> subtitles = ParseSubtitles(lines);

            // Przesuń napisy o zadaną wartość czasową
            ShiftSubtitles(subtitles, timeShift);

            // Wytnij napisy zaczynające się od równych sekund
            List<SubtitleEntry> cutSubtitles = CutSubtitles(subtitles);

            // Nadaj nową numerację napisom
            RenumberSubtitles(subtitles);
            RenumberSubtitles(cutSubtitles);

            // Zapisz przesunięte napisy do pliku
            SaveSubtitles(subtitles, outputFilePath1);

            // Zapisz wycięte napisy do nowego pliku
            SaveSubtitles(cutSubtitles, outputFilePath2);
        }

        private List<SubtitleEntry> ParseSubtitles(string[] lines)
        {
            List<SubtitleEntry> subtitles = new List<SubtitleEntry>();
            SubtitleEntry currentSubtitle = null;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (int.TryParse(line, out int subtitleNumber))
                {
                    currentSubtitle = new SubtitleEntry(subtitleNumber);
                    subtitles.Add(currentSubtitle);
                }
                else if (currentSubtitle != null)
                {
                    if (TryParseTimeSpan(line, out TimeSpan startTime, out TimeSpan endTime))
                    {
                        currentSubtitle.StartTime = startTime;
                        currentSubtitle.EndTime = endTime;
                    }
                    else
                    {
                        currentSubtitle.Text += line + Environment.NewLine;
                    }
                }
            }

            return subtitles;
        }

        private bool TryParseTimeSpan(string input, out TimeSpan startTime, out TimeSpan endTime)
        {
            startTime = endTime = TimeSpan.Zero;

            string pattern = @"(\d{2}):(\d{2}):(\d{2}),(\d{3})\s*-->\s*(\d{2}):(\d{2}):(\d{2}),(\d{3})";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                startTime = new TimeSpan(00,
                    int.Parse(match.Groups[1].Value),
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value),
                    int.Parse(match.Groups[4].Value)
                );

                endTime = new TimeSpan(00,
                    int.Parse(match.Groups[5].Value),
                    int.Parse(match.Groups[6].Value),
                    int.Parse(match.Groups[7].Value),
                    int.Parse(match.Groups[8].Value)
                );

                return true;
            }

            return false;
        }

        private void ShiftSubtitles(List<SubtitleEntry> subtitles, TimeSpan timeShift)
        {
            foreach (SubtitleEntry subtitle in subtitles)
            {
                subtitle.StartTime += timeShift;
                subtitle.EndTime += timeShift;
            }
        }

        private List<SubtitleEntry> CutSubtitles(List<SubtitleEntry> subtitles)
        {
            // Wytnij napisy zaczynające się od równych sekund
            //List<SubtitleEntry> cutSubtitles = subtitles.Where(subtitle => subtitle.StartTime.Seconds % 2 == 0).ToList();
            //subtitles.RemoveAll(subtitle => subtitle.StartTime.Seconds % 2 == 0);

                List<SubtitleEntry> cutSubtitles = subtitles.Where(subtitle => subtitle.StartTime.Milliseconds == 0).ToList();
                subtitles.RemoveAll(subtitle => subtitle.StartTime.Milliseconds == 0);

                return cutSubtitles;
        }

        private void RenumberSubtitles(List<SubtitleEntry> subtitles)
        {
            // Nadaj nową numerację napisom
            for (int i = 0; i < subtitles.Count; i++)
            {
                subtitles[i].Number = i + 1;
            }
        }

        private void SaveSubtitles(List<SubtitleEntry> subtitles, string filePath)
        {
            // Zapisz napisy do pliku
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (SubtitleEntry subtitle in subtitles)
                {
                    writer.WriteLine(subtitle.Number);
                    writer.WriteLine($"{FormatTimeSpan(subtitle.StartTime)} --> {FormatTimeSpan(subtitle.EndTime)}");
                    writer.WriteLine(subtitle.Text);
                }
            }
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            // Sformatuj TimeSpan do postaci używanej w pliku .SRT
            return $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2},{timeSpan.Milliseconds:D3}";
        }
    }

    public class SubtitleEntry
    {
        public int Number { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; }

        public SubtitleEntry(int number)
        {
            Number = number;
            StartTime = TimeSpan.Zero;
            EndTime = TimeSpan.Zero;
            Text = string.Empty;
        }
    }
}
}
