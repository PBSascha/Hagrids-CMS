using System;

namespace Hagrids_CMS.Core;

public interface ICommand
{
    string Key { get; }
    string Description { get; }
    void Execute(DataStore data);
}
