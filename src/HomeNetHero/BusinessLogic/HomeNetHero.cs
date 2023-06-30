// Ignore Spelling: App

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeNetHeroApp
{
    public class HomeNetHero
    {

        #region Members

        Scheduler _scheduler;
        ConfigWrapper _config;
        InternetConnectivityMonitor _internetConnectivityMonitor;
        IPAddressMonitor _ipAddressMonitor;
        PCInformation _pcInformation;
        SerilogWrapper _serilogWrapper;

        #endregion

        #region Public Methods

        public HomeNetHero()
        {
            // get config.
            // set up logger.

            // initialize webhook sender.
            // Initialize information classes.
            // initialize scheduler.

            // wait for start.
        }

        public void Start()
        {
            // register all tasks
            // start scheduler
        }

        public void Stop()
        {
            // kill scheduler
        }

        #endregion

        #region Private Methods

        #endregion


    }
}
