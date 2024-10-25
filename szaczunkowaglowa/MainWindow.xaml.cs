using System;
using System.Windows;

namespace MakaronWlosowy
{
    public partial class MainWindow : Window
    {
        private Head head;

        public MainWindow()
        {
            InitializeComponent();
            head = new Head();
        }

        private void CalculateByCircumference(object sender, RoutedEventArgs e)
        {
            double density = Convert.ToDouble(HairDensity.Text);
            double circumference = Convert.ToDouble(HeadCircumference.Text);
            double height = Convert.ToDouble(ForeheadHeight.Text);

            double estimatedHairCount = head.CalculateHairDensity(density, circumference, height);
            Result.Text = $"Szacunkowa liczba włosów na podstawie obwodu i wysokości czoła: {estimatedHairCount}";
        }

        private void CalculateByArea(object sender, RoutedEventArgs e)
        {
            double density = Convert.ToDouble(HairDensity.Text);
            double area = Convert.ToDouble(HeadArea.Text);

            double estimatedHairCount = head.CalculateHairDensity(density, area);
            Result.Text = $"Szacunkowa liczba włosów na podstawie powierzchni: {estimatedHairCount}";
        }
    }

    public class Head
    {
        private const double DefaultDensity = 120;
        private const double DefaultCircumference = 56;
        private const double DefaultForeheadHeight = 8;
        private const double DefaultArea = 500;

        private double hairDensity;
        private double headCircumference;
        private double foreheadHeight;
        private double headArea;

        public double HairDensity
        {
            get { return hairDensity; }
            set { hairDensity = value; }
        }

        public double HeadCircumference
        {
            get { return headCircumference; }
            set { headCircumference = value; }
        }

        public double ForeheadHeight
        {
            get { return foreheadHeight; }
            set { foreheadHeight = value; }
        }

        public double HeadArea
        {
            get { return headArea; }
            set { headArea = value; }
        }

        public Head()
        {
            hairDensity = DefaultDensity;
            headCircumference = DefaultCircumference;
            foreheadHeight = DefaultForeheadHeight;
            headArea = DefaultArea;
        }

        public double CalculateHairDensity(double density, double circumference, double height)
        {
            return density * (circumference - height);
        }

        public double CalculateHairDensity(double density, double area)
        {
            return density * area;
        }
    }
}
