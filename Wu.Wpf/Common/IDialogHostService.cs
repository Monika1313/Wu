﻿using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Wpf.Common
{
    public interface  IDialogHostService : IDialogService
    {
        /// <summary>
        /// Prism弹窗
        /// </summary>
        /// <param name="name">模块名称</param>
        /// <param name="parameters"></param>
        /// <param name="dialogHostName"></param>
        /// <returns></returns>
        Task<IDialogResult> ShowDialog(string name, IDialogParameters parameters, string dialogHostName = "Root");
    }
}
