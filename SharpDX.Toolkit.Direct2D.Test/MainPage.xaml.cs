// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace SharpDX.Toolkit.Direct2D.Test {
    public sealed partial class MainPage {
        public MainPage() {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        public MyGame MyGame { get; private set; }

        private bool IsCtrlDown { get; set; }

        private void OnLoaded(object s, RoutedEventArgs e) {
            MyGame = new MyGame();
            MyGame.Run(SwapChainPanel1);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            PushSomeStuff();
        }

        private void PushSomeStuff() {
            MyGame.PushSomeStuff();
        }

        private void MainPage_OnKeyDown(object sender, KeyRoutedEventArgs e) {
            IsCtrlDown = e.Key == VirtualKey.Control;


            if (IsCtrlDown) {
                if (e.Key == VirtualKey.P) {
                    PushSomeStuff();
                }
            }
        }

        private void MainPage_OnKeyUp(object sender, KeyRoutedEventArgs e) {
            IsCtrlDown = e.Key == VirtualKey.Control;
        }
    }
}