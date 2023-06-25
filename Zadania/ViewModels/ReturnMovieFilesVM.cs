namespace Zadania.Models
{
    public class ReturnMovieFilesVM
    {
        public ReturnMovieFilesVM() 
        {
            this.MovieTextsList = new List<MovieText>();

        }
        public bool IsOk { get; set; }
        public bool IsFirst { get; set; }
        public bool IsError { get; set; }
        public string Message  { get; set; }
        public MovieText MovieText { get; set; }
        public List<MovieText> MovieTextsList { get; set; }
    }
}
