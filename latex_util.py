from pylatex import Document, Section, Command, Itemize
from typing import List

class DatedSubsection(Section):
    def __init__(self, title, date, subtitle=None, numbering=None, *, label=True, **kwargs):
        super().__init__(title, numbering, label=label, **kwargs)
        self.latex_name = "datedsubsection"
        self.date = date
        self.subtitle = subtitle

    marker_prefix = "subsec"

    def dumps(self):
        """Represent the section as a string in LaTeX syntax.

        Returns
        -------
        str

        """

        if not self.numbering:
            num = '*'
        else:
            num = ''

        subtitle = ""
        if self.subtitle is not None:
            subtitle = self.subtitle

        string = Command(self.latex_name + num, [self.title, self.date, subtitle]).dumps()
        if self.label is not None:
            string += '%\n' + self.label.dumps()
        string += '%\n' + self.dumps_content()

        return string

def create_description(doc: Document, bullets: List[str]):
    """
    Creates a series of LaTeX bullet points given a list of strings.
    """

    with doc.create(Itemize()) as itemize:
        for bullet in bullets:
            itemize.add_item(bullet)