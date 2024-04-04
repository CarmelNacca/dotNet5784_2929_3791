

using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Dal
{
    internal class DependencyImplementation : IDependency
    {
        /// <summary>
        /// Implementation of CRUD methods according to method number 2 for XML files.
        /// </summary>

        readonly string s_dependencies_xml = "dependencies";

        static Dependency GetDependency(XElement D)
        {
            return new Dependency()
            {
                Id = int.TryParse((string?)D.Element("Id"), out var id) ? id : throw new FormatException("can't convert id"),
                IdTask = int.TryParse((string?)D.Element("IdTask"), out var idTask) ? idTask : throw new FormatException("can't convert id Task"),
                DependsOnTask = int.TryParse((string?)D.Element("DependsOnTask"), out var DependsOnTask) ? idTask : throw new FormatException("can't convert  Depends On Task")
            };
        }

        /// <summary>
        /// Creates a new dependency.
        /// </summary>
        /// <param name="item">The dependency to create.</param>
        /// <returns>The ID of the newly created dependency.</returns>
        public int Create(Dependency item)
        {
            int id = Config.NextDependencyId;
            XElement elemde = new XElement("dependency");
            XElement elemdependency = new XElement("Dependency", new XElement("Id", id),
                new XElement("IdTask", item.IdTask), new XElement("DependsOnTask", item.DependsOnTask));
            elemde.Add(elemdependency);
            XMLTools.SaveListToXMLElement(elemde, s_dependencies_xml);
            return id;
        }

        /// <summary>
        /// Deletes a dependency by ID.
        /// </summary>
        /// <param name="id">The ID of the dependency to delete.</param>
        public void Delete(int id)
        {
            XElement? Root = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
            XElement? TODelete = Root.Elements().FirstOrDefault(dependency => (int?)dependency.Element("id") == id);
            if (TODelete != null)
            {
                TODelete.Remove();
                XMLTools.SaveListToXMLElement(Root, s_dependencies_xml);
            }
        }

        /// <summary>
        /// Reads a dependency by ID.
        /// </summary>
        /// <param name="id">The ID of the dependency to read.</param>
        /// <returns>The dependency with the specified ID.</returns>
        public Dependency? Read(int id)
        {
            XElement? dependencyelm = XMLTools.LoadListFromXMLElement(s_dependencies_xml).Elements().FirstOrDefault(dependency => (int?)dependency.Element("id") == id);
            return dependencyelm is null ? null : GetDependency(dependencyelm);
        }

        /// <summary>
        /// Reads a dependency based on a filter predicate.
        /// </summary>
        /// <param name="filter">The filter predicate.</param>
        /// <returns>The first dependency matching the filter predicate, or null if not found.</returns>
        public Dependency? Read(Func<Dependency, bool> filter)
        {
            return XMLTools.LoadListFromXMLElement(s_dependencies_xml).Elements().Select(dependency => GetDependency(dependency)).FirstOrDefault();
        }

        /// <summary>
        /// Reads all dependencies, optionally applying a filter.
        /// </summary>
        /// <param name="filter">An optional filter function to apply.</param>
        /// <returns>A collection of dependencies.</returns>
        public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null)
        {
            if (filter == null)
                return XMLTools.LoadListFromXMLElement(s_dependencies_xml).Elements().Select(d => GetDependency(d));
            else
                return XMLTools.LoadListFromXMLElement(s_dependencies_xml).Elements().Select(d => GetDependency(d)).Where(filter);
        }

        /// <summary>
        /// Updates a dependency.
        /// </summary>
        /// <param name="item">The dependency to update.</param>
        public void Update(Dependency item)
        {
            if (Read(item.Id) is null)
                throw new DalDoesNotExistException($"Dependency with ID={item.Id} not exists");
            Delete(item.Id);
            XElement elemde = new XElement("item");
            XElement elemdependency = new XElement("Dependency", new XElement("Id", item.Id),
                new XElement(" Id Task", item.IdTask), new XElement("DependsOnTask", item.DependsOnTask));
            elemde.Add(elemdependency);
            elemde.Save(s_dependencies_xml);
        }

        /// <summary>
        /// Resets the list of dependencies.
        /// </summary>
        public void Reset()
        {
            XElement? elemde = XMLTools.LoadListFromXMLElement(s_dependencies_xml);
            elemde.RemoveAll();
            XMLTools.SaveListToXMLElement(elemde, s_dependencies_xml);

        }
    }
}
