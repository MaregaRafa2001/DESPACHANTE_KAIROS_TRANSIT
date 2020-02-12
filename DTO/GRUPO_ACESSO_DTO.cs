using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GRUPO_ACESSO_DTO
    {
        public int ID { get; set; }
        public int ID_PERFIL { get; set; }
        public int ID_SYS_MENU { get; set; }

        List<SYS_MENU_DTO> SYS_MENU_ = new List<SYS_MENU_DTO>();
        public List<SYS_MENU_DTO> SYS_MENU
        {
            get { return SYS_MENU_; }
            set { SYS_MENU_ = value; }
        }


        //LOG DO SISTEMA
        private LOG_SISTEMA_DTO L_DTO = new LOG_SISTEMA_DTO();
        public LOG_SISTEMA_DTO LOG_SISTEMA
        {
            get { return L_DTO; }
            set { L_DTO = value; }
        }
    }
}
