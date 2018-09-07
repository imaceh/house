using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core.baseclasses
{
    public abstract class Base: IDisposable
    {
        protected ConnectionParameters ConnectionParameters { get; private set; }
        protected DataBaseLogic DBLogic { get; private set; }

        private bool dispose_db;

        internal Base(ConnectionParameters con)
        {
            this.initializate(con, null);
        }

        private void initializate(ConnectionParameters con, DataBaseLogic db)
        {
            this.ConnectionParameters = con;
            this.DBLogic = db;

            if (this.DBLogic == null)
            {
                this.DBLogic = new DataBaseLogic(this.ConnectionParameters);
                this.dispose_db = true;
            }
            else
            {
                this.dispose_db = false;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                    if (this.dispose_db)
                    {
                        this.DBLogic.Dispose();
                        this.DBLogic = null;
                    }
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~Base() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
