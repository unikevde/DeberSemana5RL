namespace cinchiglemaMS6
{
    public partial class App : Application
    {
        public static PersonRepository PersonR{ get; set; }
        public App(PersonRepository personRepo)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.VistaDatos());
            PersonR = personRepo;
        }
    }
}
