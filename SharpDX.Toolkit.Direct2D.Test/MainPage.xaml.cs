// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SharpDX.Toolkit.Direct2D.Test {
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        private readonly MyGame _game;
        private bool _isCtrlDown;

        public MainPage() {
            InitializeComponent();
            _game = new MyGame();
            Loaded += (s, e) => _game.Run(SwapChainPanel1);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            GetValue();
        }

        private void GetValue() {
            _game.PushSomeStuff();
        }

        private void MainPage_OnKeyDown(object sender, KeyRoutedEventArgs e) {
            bool b = e.Key == VirtualKey.Control;
            
            if (b) {
                _isCtrlDown = true;
            }
            else {
                if (e.Key == VirtualKey.P) {
                    GetValue();
                }
            }
        }

        private void MainPage_OnKeyUp(object sender, KeyRoutedEventArgs e) {
            bool b = e.Key == VirtualKey.Control;
            if (b) {
                _isCtrlDown = false;
            }
            
        }
    }
}