// ------------------------------------------------------------------------
// Copyright 2021 The Dapr Authors
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//     http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ------------------------------------------------------------------------

using System;
using System.Text.Json.Serialization;
using Dapr.Client;

namespace Dapr
{
	/// <summary>
	/// Basic cloud event type with no data.
	/// </summary>        
	public class CloudEvent
	{

		/// <summary>
		/// Initialize a new instance of the <see cref="CloudEvent"/> class.
		/// </summary>        
		public CloudEvent(string type, string subject = null, string source = null, string id = null)
		{
			ArgumentVerifier.ThrowIfNullOrEmpty(type, nameof(type));
			Id = id ?? Guid.NewGuid().ToString();
			Source = source;
			Type = type;
			Subject = subject;
		}

		/// <summary>
		/// Gets event Id.
		/// </summary>
		public string Id { get; }

		/// <summary>
		/// Gets event source.
		/// </summary>
		public string Source { get; }

		/// <summary>
		/// Gets event type.
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// Gets event subject.
		/// </summary>
		public string Subject { get; }

		/// <summary>
		/// Gets event data.
		/// </summary>
		[JsonPropertyName("datacontenttype")]
		public string DataContentType { get; } = Constants.ContentTypeCloudEvent;

	}

	/// <summary>
	/// Cloud event with typed data.
	/// </summary>
	public class CloudEvent<TData> : CloudEvent
	{
		/// <summary>
		/// Initialize a new instance of the <see cref="CloudEvent{TData}"/> class.
		/// </summary>
		public CloudEvent(TData data, string type, string subject = null, string source = null, string id = null)
			: base(type, subject, source, id)
		{
			Data = data;
		}

		/// <summary>
		/// Gets event data.
		/// </summary>
		public TData Data { get; }
	}
}
