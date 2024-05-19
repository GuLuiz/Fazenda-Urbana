using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazendaUrbanaDLL.Entidades;
public class Producao
{
    public int ProducaoId { get; set; }
    public int Quantidade { get; set; }
    public int TempoCultivacao { get; set; }
    public bool Ativo { get; set; }
    public int DiasRestantes { get; set; }
    public int MateriaPrimaId { get; set; }
    public int FuncionarioId { get; set; }
}
