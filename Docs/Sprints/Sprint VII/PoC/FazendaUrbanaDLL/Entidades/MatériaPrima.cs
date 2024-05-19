using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazendaUrbanaDLL.Entidades;
public class MateriaPrima
{
    public int MateriaPrimaId { get; set; }
    public string Tipo { get; set; }
    public bool Ativo { get; set; }
    public string Nome { get; set; }
    public int ImagemId { get; set; }
    public int FornecedorId { get; set; }
}