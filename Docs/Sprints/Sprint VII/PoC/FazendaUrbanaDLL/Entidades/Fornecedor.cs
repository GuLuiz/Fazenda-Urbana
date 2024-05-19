using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazendaUrbanaDLL.Entidades;
public class Fornecedor
{
    public int FornecedorId { get; set; }
    public string Cnpj { get; set; }
    public string RazaoSocial { get; set; }
    public bool Ativo { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    public string InscricaoEstadual { get; set; }
    public string ContatosPrincipal { get; set; }
}
