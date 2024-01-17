
using Firebase.Auth;
using Firebase.Storage;

namespace ProyectoRosty.Services
{
    public class ServicioImagen : IServicioImagen
    {
        public async Task<string> SubirImagen(Stream archivo, string nombre)
        {
            string email = "sd.yugsi@itq.edu.ec";
            string clave = "steven180502";
            string ruta = "proyectoclaselibreria-da113.appspot.com";
            string api_key = "AIzaSyCDXZ03Gmr1Ov_kgf7qm7oJDNkl_lX0OPQ";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));
            var a = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
              ruta,
              new FirebaseStorageOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                  ThrowOnCancel = true
              })

               .Child("Fotos_Perfil")
               .Child(nombre)
               .PutAsync(archivo, cancellation.Token);

            var downloadURL = await task;
            return downloadURL;
        }
    }
}
