public static class ItemNames
{
    public static string Obtener(ItemID id)
    {
        switch (id)
        {
            case ItemID.paper: return "Papel";
            case ItemID.paintObject: return "Calavera";
            case ItemID.vase: return "Planta";
            case ItemID.broom: return "Escoba";
            case ItemID.lintern: return "Linterna";
            case ItemID.archiveKey: return "Llave del archivo";
            case ItemID.bossKey: return "Llave del jefe";
            case ItemID.breakKey: return "Llave de la sala de descanso";
            case ItemID.clockKey: return "Llave del reloj";
            case ItemID.conferenceKey: return "Llave de la sala de conferencias";
            case ItemID.archiversBook: return "Libro de archivos";
            case ItemID.meetingsBook: return "Libro de reuniones";
            case ItemID.bathroomBook: return "Libro de baños";
            case ItemID.breakroomBook: return "Libro de descanso";
            case ItemID.computersBook: return "Libro de compus";
            default: return id.ToString();
        }
    }
}