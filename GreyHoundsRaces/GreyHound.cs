using System.Drawing;
using System.Windows.Forms;

namespace GreyHoundsRaces
{
    public class GreyHound
    {
        public string DogName { get; set; }
        public PictureBox DogPicture { get; set; }
        public PictureBox RaceTrackLength { get; set; }

        public GreyHound(string dogname, PictureBox dogpicture, PictureBox racetracklength)
        {
            DogName = dogname;
            DogPicture = dogpicture;
            RaceTrackLength = racetracklength;
        }

        public void Move(int distance) {
            DogPicture.Location = new Point(DogPicture.Location.X + distance, DogPicture.Location.Y);
        }

        public void ResetRace()
        {
            DogPicture.Location = new Point(12, DogPicture.Location.Y);
        }

    }
}
