using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryville.Interop.Java {
	/// <summary>
	/// Java VM manager.
	/// </summary>
	public class JavaVMManager {
		static JavaVMManager m_instance;
		/// <summary>
		/// Gets an instance of the <see cref="JavaVMManager" /> singleton class.
		/// </summary>
		public static JavaVMManager Instance {
			get {
				if (m_instance == null)
					m_instance = new JavaVMManager();
				return m_instance;
			}
		}
		JavaVMManager() { }

		/// <summary>
		/// Registers a Java VM.
		/// </summary>
		/// <param name="vm">A Java VM.</param>
		/// <exception cref="ArgumentNullException"><paramref name="vm" /> is <see langword="null" />.</exception>
		public void Register(IJniInvoke vm) {
			if (vm == null) throw new ArgumentNullException(nameof(vm));
			if (m_vms.Contains(vm)) return;
			m_vms.Add(vm);
		}

		readonly List<IJniInvoke> m_vms = new List<IJniInvoke>();
		/// <summary>
		/// All registered Java VMs.
		/// </summary>
		public IEnumerable<IJniInvoke> VMs => m_vms;
		/// <summary>
		/// The current VM.
		/// </summary>
		public IJniInvoke CurrentVM => m_vms.Single();
	}
}
