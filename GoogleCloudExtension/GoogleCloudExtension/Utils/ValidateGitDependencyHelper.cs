﻿// Copyright 2017 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using GoogleCloudExtension.Git;
using GoogleCloudExtension.LinkPrompt;
using System;

namespace GoogleCloudExtension.Utils
{
    /// <summary>
    /// Helper functions that validate if git for windows is installed.
    /// </summary>
    public static class ValidateGitDependencyHelper
    {
        /// <summary>
        /// The link to install git.
        /// </summary>
        internal const string GitInstallationLink = "https://git-scm.com/download/win";

        /// <summary>
        /// Asking to install Git for Windows if git.exe is not found
        /// </summary>
        /// <returns>
        /// True: It is installed properly.
        /// Otherwise, returns false.
        /// </returns>
        public static bool ValidateGitForWindowsInstalled()
        {
            if (String.IsNullOrWhiteSpace(GitRepository.GetGitPath()))
            {
                LinkPromptDialogWindow.PromptUser(
                        Resources.GitUtilsMissingGitErrorTitle,
                        Resources.GitUtilsMissingGitErrorMessage,
                        new LinkInfo(link: GitInstallationLink, caption: Resources.GitUtilsGitInstallLinkCaption));
                return false;
            }
            return true;
        }
    }
}
