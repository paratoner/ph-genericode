/**
 * Copyright (C) 2014-2015 Philip Helger (www.helger.com)
 * philip[at]helger[dot]com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *         http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
package com.helger.genericode;

import javax.annotation.Nonnull;
import javax.xml.bind.JAXBElement;

import com.helger.genericode.v10.CodeListDocument;
import com.helger.genericode.v10.ObjectFactory;
import com.helger.jaxb.AbstractJAXBMarshaller;

/**
 * This is the reader and writer for Genericode 1.0 code lists. This class may
 * be derived to override protected methods from {@link AbstractJAXBMarshaller}.
 *
 * @author Philip Helger
 */
public class Genericode10CodeListMarshaller extends AbstractJAXBMarshaller <CodeListDocument>
{
  /**
   * Constructor
   */
  public Genericode10CodeListMarshaller ()
  {
    super (CodeListDocument.class, CGenericode.GENERICODE_10_XSDS);
  }

  @Override
  @Nonnull
  protected final JAXBElement <CodeListDocument> wrapObject (final CodeListDocument aCodeListDocument)
  {
    return new ObjectFactory ().createCodeList (aCodeListDocument);
  }
}
