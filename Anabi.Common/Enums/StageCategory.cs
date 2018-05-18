using System;
using System.Collections.Generic;
using System.Text;

namespace Anabi.Common.Enums
{
    public enum StageCategory
    {
        /// <summary>
        /// Sechestru
        /// </summary>
        Sequester = 1,
        Confiscation = 2,
        /// <summary>
        /// Ridicare sechestru
        /// </summary>
        LiftingSeizure =3,

        /// <summary>
        /// Valorificare Anticipata/Standard
        /// </summary>
        Recovery = 4,

        /// <summary>
        /// Administrare simpla
        /// </summary>
        SimpleAdministration = 5,

        /// <summary>
        /// Reutilizare sociala
        /// </summary>
        SocialReuse = 6
    }
}
