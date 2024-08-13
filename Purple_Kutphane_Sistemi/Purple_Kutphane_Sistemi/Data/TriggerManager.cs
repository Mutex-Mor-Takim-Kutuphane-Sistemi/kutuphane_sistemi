using Npgsql;

namespace Purple_Kutphane_Sistemi.Data
{
    public class TriggerManager
    {
        private readonly string connectionString;

        public TriggerManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateSetSonOnaylanmaTarihiTrigger()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                var createFunctionCmd = @"
            CREATE OR REPLACE FUNCTION set_son_onaylanma_tarihi_on_insert()
            RETURNS TRIGGER AS $$
            BEGIN
                NEW.son_onaylanma_tarihi := CURRENT_TIMESTAMP + INTERVAL '1 day';
                RETURN NEW;
            END;
            $$ LANGUAGE plpgsql;";

                var createTriggerCmd = @"
            CREATE TRIGGER hesap_talebi_son_onaylanma_tarihi_trigger
            BEFORE INSERT ON hesap_talebi
            FOR EACH ROW
            EXECUTE FUNCTION set_son_onaylanma_tarihi_on_insert();";

                using (var command = new NpgsqlCommand(createFunctionCmd, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new NpgsqlCommand(createTriggerCmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateKitapAlmaTalebiTrigger()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                var createFunctionCmd = @"
            CREATE OR REPLACE FUNCTION set_son_onaylanma_tarihi_on_insert()
            RETURNS TRIGGER AS $$
            BEGIN
                NEW.son_onaylanma_tarihi := CURRENT_TIMESTAMP + INTERVAL '1 day';
                RETURN NEW;
            END;
            $$ LANGUAGE plpgsql;";

                var createTriggerCmd = @"
            CREATE TRIGGER kitap_alma_talebi_son_onaylanma_tarihi_trigger
            BEFORE INSERT ON kitap_alma_talebi
            FOR EACH ROW
            EXECUTE FUNCTION set_son_onaylanma_tarihi_on_insert();";

                using (var command = new NpgsqlCommand(createFunctionCmd, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new NpgsqlCommand(createTriggerCmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateKitapAlimlariTrigger()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                var createFunctionCmd = @"
            CREATE OR REPLACE FUNCTION set_teslim_tarihi_on_insert()
            RETURNS TRIGGER AS $$
            BEGIN
                NEW.teslim_tarihi := CURRENT_TIMESTAMP + INTERVAL '14 day';
                RETURN NEW;
            END;
            $$ LANGUAGE plpgsql;";

                var createTriggerCmd = @"
            CREATE TRIGGER kitap_alimlari_teslim_tarihi_trigger
            BEFORE INSERT ON kitap_alimlari
            FOR EACH ROW
            EXECUTE FUNCTION set_teslim_tarihi_on_insert();";

                using (var command = new NpgsqlCommand(createFunctionCmd, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new NpgsqlCommand(createTriggerCmd, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
