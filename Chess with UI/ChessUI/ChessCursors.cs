using System.IO;
using System.Windows;
using System.Windows.Input;

namespace ChessUI
{
    public static class ChessCursors
    {
        public static readonly Cursor WhiteCursor = LoadCursor("C:\\Users\\DeepCooL\\source\\repos\\ChessGame\\ChessUI\\Assets\\CursorW.cur");
        public static readonly Cursor BlackCursor = LoadCursor("C:\\Users\\DeepCooL\\source\\repos\\ChessGame\\ChessUI\\Assets\\CursorB.cur");

        private static Cursor LoadCursor(string filePath)
        {
            Stream stream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative)).Stream;
            return new Cursor(stream, true);
        }
    }
}
