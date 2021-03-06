﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EterManager.Base;
using EterManager.Models;
using EterManager.Utilities;

namespace EterManager.UserInterface.ViewModels.TreeItem
{
    /// <summary>
    /// Represents a file in a TreeView
    /// </summary>
    class TreeItemFileVm : ViewModelBase, ITreeViewItem
    {
       #region Fields

        /// <summary>
        /// DoubleClickCommand RelayCommand obj
        /// </summary>
        private RelayCommand _doubleClick;

        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless Ctor
        /// </summary>
        public TreeItemFileVm() : this(null) { }

        /// <summary>
        /// Main Ctor
        /// </summary>
        public TreeItemFileVm(ITreeViewItem parent)
        {
            // Member initialization
            IsVisible = true;
            Parent = parent;
            IsFolder = false;

            // Initialize commands
            InitializeCommands();
        }

        /// <summary>
        /// Initializes all commands
        /// </summary>
        private void InitializeCommands()
        {
            _doubleClick = new RelayCommand(p => DoubleClickCommandAction(), p => true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs file search
        /// </summary>
        /// <param name="pattern"></param>
        public void PerformFileSearch(string pattern)
        {
            if (DisplayName.ToLower().Contains(pattern.ToLower()))
                SetVisibility(true);
            else
            {
                IsVisible = false;
            }
        }

        /// <summary>
        /// Sets visibility of the item and all its ancestors
        /// </summary>
        /// <param name="value"></param>
        public void SetVisibility(bool value)
        {
            IsVisible = value;

            // Set parent's visibility to the same value if not null
            if (Parent != null)
                Parent.SetVisibility(value);
        }

        #endregion

        #region Commands

        #region Command Actions

        /// <summary>
        /// Action performed when DoubleClickCommand is hit
        /// </summary>
        private void DoubleClickCommandAction()
        {
            
        }

        #endregion

        #region Command Evaluators

        #endregion

        #region Command Interfaces

        /// <summary>
        /// DoubleClickCommand interface
        /// </summary>
        public ICommand DoubleClickCommand
        {
            get { return _doubleClick; }
        }

        #endregion

        #endregion

        #region Properties

        #region Proxy Properties

        #endregion

        #region Presentation Members

        private string _displayName;

        /// <summary>
        /// Display name of the TreeItem
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { SetProperty(ref _displayName, value, "DisplayName"); }
        }

        private string _fullname;

        /// <summary>
        /// Item's fullname
        /// </summary>
        public string Fullname
        {
            get { return _fullname; }
            set { SetProperty(ref _fullname, value, "Fullname"); }
        }
        
        private bool _isSelected;

        /// <summary>
        /// Defines wether the item is selected
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value, "IsSelected"); }
        }

        private bool _isVisible;

        /// <summary>
        /// Defines wether the item is visible
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value, "IsVisible"); }
        }

        private bool _isExpanded;

        /// <summary>
        /// Defines wether the item is expanded
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value, "IsExpanded"); }
        }

        private ITreeViewItem _parent;

        /// <summary>
        /// Reference to parent item
        /// </summary>
        public ITreeViewItem Parent
        {
            get { return _parent; }
            set { SetProperty(ref _parent, value, "Parent"); }
        }


        private string _eterFileParent;

        /// <summary>
        /// Eter file parent
        /// </summary>
        public string EterFileParent
        {
            get { return _eterFileParent; }
            set { SetProperty(ref _eterFileParent, value, "EterFileParent"); }
        }

        private bool _isFolder;

        /// <summary>
        /// Defines wether object is folder or not
        /// </summary>
        public bool IsFolder
        {
            get { return _isFolder; }
            set { SetProperty(ref _isFolder, value, "IsFolder"); }
        }

        #endregion

        #region Others

        #endregion

        #endregion

        #region Destructor

        #endregion


    }
}
