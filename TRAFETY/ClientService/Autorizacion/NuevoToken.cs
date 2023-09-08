using System.Timers;
using Timer = System.Timers.Timer;

namespace TRAFETY.ClientService.Autorizacion
{
    public class NuevoToken : IDisposable
    {
        const int Intervalo = 60000;  // 60 segundos
        private readonly ILoginService loginService;

        public NuevoToken(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        Timer? timer;

        public void Iniciar()
        {
            timer = new Timer();
            timer.Interval = Intervalo; 
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            loginService.ManejarRenovacionToken();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
