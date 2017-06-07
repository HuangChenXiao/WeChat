using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatSDK.Service
{
    public class account
    {
        private string _kf_account;
        public string kf_account
        {
            get { return _kf_account; }
            set { _kf_account = value; }
        }
        private string _nickname;

        public string nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        private string _invite_wx;

        public string invite_wx
        {
            get { return _invite_wx; }
            set { _invite_wx = value; }
        }
    }
}