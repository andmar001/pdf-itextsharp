using iTextSharp.text;

namespace pdf_generator.Models
{
    public class Propiedades
    {
        public Propiedades()
        {
            UniqueId = Guid.NewGuid().ToString().Replace("-", "");
            Nombre = UniqueId + ".pdf";
            Lorem = "Lorem ipsum dolor sit amet consectetur adipisicing elit. In porro officiis molestiae, provident, vero deleniti consequatur voluptate cumque, enim consequuntur ullam cum labore magnam dolorum esse ab exercitationem. Facere consectetur, harum iusto soluta officia aspernatur suscipit quasi ipsum sint nobis officiis fugiat maxime ratione? Illum magni libero eveniet temporibus aperiam impedit ducimus rem error! Rem deserunt, expedita, reiciendis consequatur iste vero animi eius repellendus blanditiis nobis quibusdam laboriosam. Dignissimos aliquam sint, natus iste quos, veniam laudantium blanditiis optio, ipsam officiis ex veritatis ab quod voluptatibus a? Magnam nemo accusantium, autem nesciunt, sit quo voluptatum quis rerum deserunt beatae molestias amet?, Lorem ipsum dolor sit amet consectetur adipisicing elit. In porro officiis molestiae, provident, vero deleniti consequatur voluptate cumque, enim consequuntur ullam cum labore magnam dolorum esse ab exercitationem. Facere consectetur, harum iusto soluta officia aspernatur suscipit quasi ipsum sint nobis officiis fugiat maxime ratione? Illum magni libero eveniet temporibus aperiam impedit ducimus rem error! Rem deserunt, expedita, reiciendis consequatur iste vero animi eius repellendus blanditiis nobis quibusdam laboriosam. Dignissimos aliquam sint, natus iste quos, veniam laudantium blanditiis optio, ipsam officiis ex veritatis ab quod voluptatibus a? Magnam nemo accusantium, autem nesciunt, sit quo voluptatum quis rerum deserunt beatae molestias amet?"
            ;
        }
        public string UniqueId { get; set; }
        public string Nombre { get; set; }
        public string Lorem { get; set; }
    }
}