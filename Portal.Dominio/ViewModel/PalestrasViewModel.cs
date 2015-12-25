using System.Collections.Generic;

namespace Portal.Dominio.ViewModel
{
    public class PalestrasViewModel
    {
        public Pessoa Pessoa { get; set; }
        public IEnumerable<Palestra> Palestras { get; set; }
        public IEnumerable<Palestra> PalestrasSelecionadas { get; set; }
        public PalestrasAdicionadas PalestrasAdicionadas { get; set; }
        

    }
}
