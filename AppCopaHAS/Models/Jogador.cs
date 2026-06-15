using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCopaHAS.Models
{
    public class Jogador
    {
        public int Id { get; set; } // Prop + TAB -> atalho propriedades
        public string Nome { get; set; } = "";
        public int NumeroCamisa { get; set; }
        public string Posicao { get; set; } = string.Empty;
        public int SelecaoId { get; set; }
        public byte[]? Foto { get; set; } // Array de Bytes para obter a imagem

        public ImageSource FotoSource
        {
            get
            {
                if (Foto == null || Foto.Length == 0)
                    return "semfoto.png";

                return ImageSource.FromStream(() => new MemoryStream(Foto));
            }
        }
    }
}
