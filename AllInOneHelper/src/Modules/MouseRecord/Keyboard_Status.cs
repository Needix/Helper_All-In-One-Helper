using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.MouseRecord {
    static class Keyboard_Status {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        public static byte[] GetStatus() {
            byte[] array = new byte[256];
            for(int i = 0; i < array.Length; i++) {
                char character = (char)i;
                short status = GetAsyncKeyState(character);
                byte leastSignificantBit = (byte)(status & 0xFF);
                byte mostSignificantBit = (byte)((status & 0xFF00) >> 15);
                array[i] = mostSignificantBit;
            }

            return array;
        }

        public static byte GetVirtualKeyCode(Keys key) {
            int value = (int)key;
            return (byte)(value & 0xFF);
        }
    }
}
